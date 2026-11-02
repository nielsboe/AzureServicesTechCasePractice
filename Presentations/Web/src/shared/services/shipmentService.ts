import { Product } from '../models/product';

export class ProductService {
    public async getAllProducts(): Promise<Product[]> {
        const response = await fetch('https://localhost:5001/api/Product/GetAllProducts');
        const data = await response.json();
        return data as Product[];
    } 

    public async GetProductById(id: number): Promise<Product> {
        const response = await fetch(`https://localhost:5001/api/Product/GetSingleProduct/${id}`);
        const data = await response.json();
        return this.mapProductDTOToProduct(data);
    }

    public mapProductDTOToProduct(productDTO: any): Product {
        return new Product(
            productDTO.Id,
            productDTO.InternalProductId,
            productDTO.Name,
            productDTO.Description,
            productDTO.Price
        );
    }
}