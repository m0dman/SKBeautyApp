import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpResponse } from '@angular/common/http';
import { Booking } from '../models/booking/booking';
import { CreateBooking } from '../models/booking/createBooking';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  public api_url_tag: string;

  constructor(private apiService: ApiService) {
    this.api_url_tag = 'booking';
  }

  GetBranches(): Promise<HttpResponse<Booking[]>> {
    return this.apiService.get<Booking[]>(`${this.api_url_tag}/Get/`);
  }

  GetBookingById(id: number): Promise<HttpResponse<Booking>> {
    return this.apiService.get<Booking>(`${this.api_url_tag}/GetBooking/${id}`);
  }

  CreateBooking(booking: CreateBooking): Promise<HttpResponse<number>> {
    return this.apiService.post(`${this.api_url_tag}/CreateBooking`, booking)
  }
}
