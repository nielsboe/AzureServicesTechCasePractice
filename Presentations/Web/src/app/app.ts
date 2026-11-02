import { CurrencyPipe } from '@angular/common';
import { Component, signal } from '@angular/core';
import { Order } from '../shared/models/order';
import { Product } from '../shared/models/product';
import { Shipment } from '../shared/models/shipment';
import { Products } from './products/products';

@Component({
  standalone: true,
  selector: 'app-root',
  imports: [CurrencyPipe, Products],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {
  public readonly title = signal('Homes');
  public readonly status = signal('Ready');
  public readonly lastResult = signal('');

  products = [
    new Product(1, 101, 'Product A', 'Description A', 10.99),
    new Product(2, 102, 'Product B', 'Description B', 19.99),
    new Product(3, 103, 'Product C', 'Description C', 5.49)
  ]

  orders = [
    new Order(1, 101, 'Customer A', new Date(), false, [], 0.0),
    new Order(2, 102, 'Customer B', new Date(), false, [], 0.0),
    new Order(3, 103, 'Customer C', new Date(), false, [], 0.0)
  ]

  shipments = [
    new Shipment(1, 101, 10920261, 'Description A', this.products, new Date()),
    new Shipment(2, 102, 10920262, 'Description B', this.products, new Date()),
    new Shipment(3, 103, 10920263, 'Description C', this.products, new Date())
  ]
  
  private readonly apiBase = '';

  public async getOrders() {
    await this.callApi('/api/Order/GetAllOrders');
  }

  public async createOrder() {
    await this.callApi('/api/Order/CreateOrder', {
      method: 'POST',
      body: JSON.stringify({
        id: 0,
        internalOrderId: 999,
        customerName: 'Demo Customer',
        orderDate: new Date().toISOString(),
        isShipped: false,
        products: [],
        totalOrderPrice: 0.0
      })
    });
  }

  public async updateOrder() {
    await this.callApi('/api/Order/UpdateOrder', {
      method: 'POST',
      body: JSON.stringify({
        id: 1,
        internalOrderId: 999,
        customerName: 'Updated Customer',
        orderDate: new Date().toISOString(),
        isShipped: true,
        products: [],
        totalOrderPrice: 0.0
      })
    });
  }

  public async deleteOrder() {
    await this.callApi('/api/Order/DeleteOrder', {
      method: 'POST',
      body: JSON.stringify({
        id: 1,
        internalOrderId: 999,
        customerName: 'Updated Customer',
        orderDate: new Date().toISOString(),
        isShipped: true,
        products: [],
        totalOrderPrice: 0.0
      })
    });
  }

  public async getProducts() {
    await this.callApi('/api/Product/GetAllProducts');
  }

  public async createProduct() {
    await this.callApi('/api/Product/CreateProduct', {
      method: 'PUT',
      body: JSON.stringify({
        id: 0,
        internalProductId: 123,
        name: 'Demo Product',
        description: 'Created from Web app',
        price: 9.99
      })
    });
  }

  public async updateProduct() {
    await this.callApi('/api/Product/UpdateProduct', {
      method: 'POST',
      body: JSON.stringify({
        id: 1,
        internalProductId: 123,
        name: 'Updated Product',
        description: 'Updated from Web app',
        price: 19.99
      })
    });
  }

  public async deleteProduct() {
    await this.callApi('/api/Product/DeleteProduct', {
      method: 'DELETE',
      body: JSON.stringify({
        id: 1,
        internalProductId: 123,
        name: 'Updated Product',
        description: 'Updated from Web app',
        price: 19.99
      })
    });
  }

  public async getShipments() {
    await this.callApi('/api/Shipping/GetAllhipments');
  }

  public async createShipment() {
    await this.callApi('/api/Shipping/CreateShipment', {
      method: 'POST',
      body: JSON.stringify({
        id: 0,
        internalShipmentId: 456,
        orderId: 1,
        shipmentAddress: '123 Demo Street',
        products: [],
        shipmentDate: new Date().toISOString()
      })
    });
  }

  public async updateShipment() {
    await this.callApi('/api/Shipping/UpdateShipment', {
      method: 'POST',
      body: JSON.stringify({
        id: 1,
        internalShipmentId: 456,
        orderId: 1,
        shipmentAddress: '456 Updated Ave',
        products: [],
        shipmentDate: new Date().toISOString()
      })
    });
  }

  public async deleteShipment() {
    await this.callApi('/api/Shipping/DeleteShipment', {
      method: 'POST',
      body: JSON.stringify({
        id: 1,
        internalShipmentId: 456,
        orderId: 1,
        shipmentAddress: '456 Updated Ave',
        products: [],
        shipmentDate: new Date().toISOString()
      })
    });
  }

  private async callApi(path: string, options: RequestInit = {}) {
    this.status.set('Loading...');
    this.lastResult.set('');

    try {
      const response = await fetch(`${this.apiBase}${path}`, {
        headers: {
          'Content-Type': 'application/json'
        },
        ...options
      });

      if (!response.ok) {
        const errorText = await response.text();
        this.status.set('Error');
        this.lastResult.set(`HTTP ${response.status}: ${errorText}`);
        return;
      }

      const contentType = response.headers.get('content-type') ?? '';
      if (contentType.includes('application/json')) {
        const json = await response.json();
        this.lastResult.set(JSON.stringify(json, null, 2));
      } else {
        this.lastResult.set(await response.text());
      }

      this.status.set('Success');
    } catch (error) {
      this.status.set('Failed');
      this.lastResult.set(String(error));
    }
  }
}
