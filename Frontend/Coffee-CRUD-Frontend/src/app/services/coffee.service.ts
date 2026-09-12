import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Coffee {
  id: number;
  name: string;
  texture: string;
  description: string | null;
  roast: string;
  origin: string;
  process: string;
  brand: string;
  price: number;
}

@Injectable({
  providedIn: 'root',
})
export class CoffeeService {
  private apiUrl = 'http://localhost:5215/api/coffees';

  constructor(private http: HttpClient) {}

  // Fetch coffee data
  getCoffee(): Observable<Coffee[]> {
    return this.http.get<Coffee[]>(this.apiUrl);
  }

  // Send coffee over
  addCoffee(data: Coffee): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }
}
