import { Order } from '../models/order';

export class OrderService {
    public async getAllOrders(): Promise<Order[]> {
        const response = await fetch('https://localhost:5001/api/Order/GetAllOrders');
        const data = await response.json();
        return data as Order[];
    }

    public async GetOrderById(id: number): Promise<Order> {
        const response = await fetch(`https://localhost:5001/api/Order/GetSingleOrder/${id}`);
        const data = await response.json();
        return this.mapOrderDTOToOrder(data);
    }

    public mapOrderDTOToOrder(orderDTO: any): Order {
        return new Order(
            orderDTO.Id,
            orderDTO.InternalOrderId,
            orderDTO.CustomerName,
            orderDTO.OrderDate,
            orderDTO.IsShipped,
            orderDTO.Products,
            orderDTO.TotalOrderPrice
        );
    }
}