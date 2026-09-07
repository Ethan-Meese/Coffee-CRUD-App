import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { CrudComponent } from './crud/crud.component';
import { ProductsComponent } from './products/products.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, CrudComponent, ProductsComponent],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('Coffee-CRUD-Fronend');
}
