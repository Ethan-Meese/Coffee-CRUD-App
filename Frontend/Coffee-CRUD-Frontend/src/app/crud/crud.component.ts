import { Component, EventEmitter, Input, OnInit, Output, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { CoffeeService, type Coffee, type CreateCoffee } from '../services/coffee.service';

@Component({
  selector: 'app-crud',
  imports: [ReactiveFormsModule],
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.css'],
})
export class CrudComponent implements OnInit {
  private coffeeServie = inject(CoffeeService);
  private fb = inject(FormBuilder);

  @Output() coffeeLoaded = new EventEmitter<Coffee[]>();
  private postCoffee!: CreateCoffee;
  public crudCase?: string;

  constructor() {}

  ngOnInit() {}

  coffeeForm = this.fb.nonNullable.group({
    name: ['', Validators.required],
    texture: ['', Validators.required],
    description: ['', Validators.required],
    roast: ['', Validators.required],
    origin: ['', Validators.required],
    process: ['', Validators.required],
    brand: ['', Validators.required],
    price: [0, Validators.required],
  });

  getCoffee(): void {
    this.coffeeServie.getCoffee().subscribe((result) => {
      this.coffeeLoaded.emit(result);
      console.log(result);
    });
  }

  addCoffee(data: CreateCoffee) {
    this.coffeeServie.addCoffee(data).subscribe({
      next: (response) => console.log('Success!', response),
      error: (err) => console.log(err),
    });
  }

  addCoffeeFromSubmit() {
    if (this.coffeeForm.valid) {
      this.postCoffee = this.coffeeForm.getRawValue();
      this.addCoffee(this.postCoffee);
    }
  }

  crudButtonCase(crudCase: string): void {
    this.crudCase = crudCase;
  }
}
