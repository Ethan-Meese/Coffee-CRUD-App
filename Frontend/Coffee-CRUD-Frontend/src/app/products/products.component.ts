import { Component, Input, OnInit } from '@angular/core';
import { Coffee } from '../services/coffee.service';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  @Input() coffees: Coffee[] = [];
  constructor() {}

  ngOnInit() {}
}
