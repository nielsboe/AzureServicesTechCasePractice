import { Component } from '@angular/core';
import { App } from '../../app/app';
import { CurrencyPipe } from '@angular/common';
import { ProductNames } from './product-names/product-names';

@Component({
  selector: 'app-products',
  imports: [CurrencyPipe, ProductNames],
  templateUrl: './products.html',
  styleUrl: './products.css',
})

export class Products {
  app = new App();
}
