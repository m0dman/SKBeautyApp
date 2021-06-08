import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Booking } from 'src/app/models/booking/booking';
import { IBooking } from 'src/app/models/interfaces/ibooking';
import { BookingService } from 'src/app/services/booking.service';

@Component({
  selector: 'app-reference-search',
  templateUrl: './reference-search.component.html',
  styleUrls: ['./reference-search.component.scss']
})
export class ReferenceSearchComponent implements OnInit {
searchFormGroup: FormGroup;
booking: Booking;
referenceNumber: number;
showCard: boolean = false;

  constructor(private _formBuilder: FormBuilder,private bookingService: BookingService) { }

  ngOnInit(): void {
    this.searchFormGroup = this._formBuilder.group({
      reference: ['', Validators.required]
    });
  }

  get reference() {
    return this.searchFormGroup.get('reference')
  }

  search() {
    console.log(this.reference);
    this.referenceNumber = this.reference.value; 
    this.bookingService.GetBookingById(this.referenceNumber).then((res: HttpResponse<IBooking>) => {
      this.booking = res.body;
      this.showCard = true;
    });
  }
}
