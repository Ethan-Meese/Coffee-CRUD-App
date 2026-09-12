import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CoffeeService, type Coffee } from '../services/coffee.service';

@Component({
  selector: 'app-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.css'],
})
export class CrudComponent implements OnInit {
  @Output() coffeeLoaded = new EventEmitter<Coffee[]>();

  constructor(private coffeeServie: CoffeeService) {}

  ngOnInit() {}

  getCoffee(): void {
    this.coffeeServie.getCoffee().subscribe((result) => {
      this.coffeeLoaded.emit(result);
      console.log(result);
    });
  }
}
