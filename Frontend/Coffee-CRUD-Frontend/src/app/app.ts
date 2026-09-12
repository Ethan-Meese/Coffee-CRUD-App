import { Component, signal } from '@angular/core';
import { Coffee } from './services/coffee.service';
import { HeaderComponent } from './header/header.component';
import { CrudComponent } from './crud/crud.component';
import { ProductsComponent } from './products/products.component';

@Component({
  selector: 'app-root',
  imports: [HeaderComponent, CrudComponent, ProductsComponent],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  coffees: Coffee[] = [];
  protected readonly title = signal('Coffee-CRUD-Fronend');

  updateCoffeeList(coffees: Coffee[]): void {
    this.coffees = coffees;
  }
}
