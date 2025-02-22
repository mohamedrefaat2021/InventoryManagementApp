using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryManagementApp.Interface;
using InventoryManagementApp.Models;
using System.Collections.ObjectModel;
using System.Windows;

public partial class InventoryViewModel : ObservableObject
{
    private readonly IInventoryRepository _repository;

    [ObservableProperty]
    private ObservableCollection<InventoryItem> _items = new();

    [ObservableProperty]
    private InventoryItem? _selectedItem;

    [ObservableProperty]
    private InventoryItem _newItem = new();

    [ObservableProperty]
    private string _searchText = string.Empty;

    public ObservableCollection<InventoryItem> FilteredItems =>
        new(Items.Where(item =>
            string.IsNullOrEmpty(SearchText) ||
            item.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
            item.Category.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));

    public InventoryViewModel(IInventoryRepository repository)
    {
        _repository = repository;

        LoadItemsCommand = new AsyncRelayCommand(LoadItems);
        SaveItemCommand = new AsyncRelayCommand(SaveItem);
        AddItemCommand = new AsyncRelayCommand(AddItem);

        _ = LoadItems();
    }

    public IAsyncRelayCommand LoadItemsCommand { get; }
    public IAsyncRelayCommand SaveItemCommand { get; }
    public IAsyncRelayCommand AddItemCommand { get; }

    public async Task LoadItems()
    {
        Items = new ObservableCollection<InventoryItem>(await _repository.GetAllItemsAsync());
        OnPropertyChanged(nameof(FilteredItems));
    }

    public async Task SaveItem()
    {
        if (SelectedItem == null) return;

        await _repository.UpdateItemAsync(SelectedItem);
        await LoadItems();
        MessageBox.Show("Item updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    public async Task AddItem()
    {
        if (string.IsNullOrWhiteSpace(NewItem.Name))
        {
            MessageBox.Show("Item name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(NewItem.Category))
        {
            MessageBox.Show("Item category is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (NewItem.StockQuantity <= 0)
        {
            MessageBox.Show("Stock quantity must be greater than zero.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        await _repository.AddItemAsync(NewItem);
        await LoadItems();
        NewItem = new InventoryItem();

        MessageBox.Show("Item added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    partial void OnSearchTextChanged(string value)
    {
        OnPropertyChanged(nameof(FilteredItems));
    }
}
