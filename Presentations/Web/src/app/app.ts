import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-root',
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Web');
  protected readonly status = signal('Ready');
  protected readonly lastResult = signal('');

  private readonly apiBase = '';

  protected async getOrders() {
    await this.callApi('/api/Order/GetAllOrders');
  }

  protected async createOrder() {
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

  protected async updateOrder() {
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

  protected async deleteOrder() {
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

  protected async getProducts() {
    await this.callApi('/api/Product/GetAllProducts');
  }

  protected async createProduct() {
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

  protected async updateProduct() {
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

  protected async deleteProduct() {
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

  protected async getShipments() {
    await this.callApi('/api/Shipping/GetAllhipments');
  }

  protected async createShipment() {
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

  protected async updateShipment() {
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

  protected async deleteShipment() {
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
