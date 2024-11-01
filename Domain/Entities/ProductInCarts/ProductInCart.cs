using Domain.Entities.ProductInCarts.Parameters;

namespace Domain.Entities.ProductInCarts;

public sealed class ProductInCart
{
    private Guid _id = Guid.NewGuid();

    private Guid _productId;
    private Guid _bucketId;

    private int _quantity;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    
    private ProductInCart()
    {
    }

    internal ProductInCart(CreateProductInCartParameters parameters) : this()
    {
        SetBucket(new SetProductInCartBucketParameters
        {
            BucketId = parameters.BucketId,
            TimeProvider = parameters.TimeProvider
        });
        
        SetProduct(new SetProductInBucketProductParameters
        {
            ProductId = parameters.ProductId,
            TimeProvider = parameters.TimeProvider
        });
        
        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;
    
    public Guid BucketId => _bucketId;
    public Guid ProductId => _productId;

    public int Quantity => _quantity;
    
    public DateTimeOffset CreatedAt => _createdAt;

    public DateTimeOffset UpdatedAt => _updatedAt;
    
    private void SetProduct(SetProductInBucketProductParameters parameters)
    {
        _productId = parameters.ProductId;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    private void SetBucket(SetProductInCartBucketParameters parameters)
    {
        _bucketId = parameters.BucketId;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void AddProduct(AddProductInCartQuantityParameters parameters)
    {
        _quantity = parameters.Quantity;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void RemoveProduct(RemoveProductInCartQuantityParameters parameters)
    {
        _quantity = parameters.Quantity;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    private void SetQuantity(SetProductInBucketQuantityParameters parameters)
    {
        if (parameters.Quantity < 0)
        {
            _quantity = default;
            _updatedAt = parameters.TimeProvider.GetUtcNow();
            return;
        }
        
        _quantity = parameters.Quantity;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}