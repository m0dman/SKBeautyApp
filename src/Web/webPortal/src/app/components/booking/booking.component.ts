import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Booking } from 'src/app/models/booking/booking';
import { CreateBooking } from 'src/app/models/booking/createBooking';
import { Branch } from 'src/app/models/branch/branch';
import { IBranch } from 'src/app/models/interfaces/ibranch';
import { ITreatment } from 'src/app/models/interfaces/itreatment';
import { Treatment } from 'src/app/models/treatment/treatment';
import { BookingService } from 'src/app/services/booking.service';
import { BranchService } from 'src/app/services/branch.service';
import { TreatmentService } from 'src/app/services/treatment.service';
import { ConfirmationDialogComponent } from './dialogs/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.scss']
})
export class BookingComponent implements OnInit {
  isLinear = true;
  detailsFormGroup: FormGroup;
  branchFormGroup: FormGroup;
  treatmentFormGroup: FormGroup;
  dateTimeFormGroup: FormGroup;
  booking: Booking = new Booking();
  newBooking: CreateBooking = new CreateBooking();
  branches: Branch[] = [];
  treatments: Treatment[] = [];
  selectedBranch: Branch;
  selectedTreatment: Treatment;
  
  constructor(private _formBuilder: FormBuilder, private branchService: BranchService, private treatmentService: TreatmentService, private bookingService: BookingService, private dialog: MatDialog, private router: Router) { }

  ngOnInit(): void {
    this.detailsFormGroup = this._formBuilder.group({
      firstName: ['', Validators.required],
      surname: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      telephoneNumber: ['', Validators.required],
      email: ['', Validators.email],
      address: ['', Validators.required],
    });
    this.branchFormGroup = this._formBuilder.group({
      branch: ['', Validators.required]
    });
    this.treatmentFormGroup = this._formBuilder.group({
      treatment: ['', Validators.required]
    });
    this.dateTimeFormGroup = this._formBuilder.group({
      // dateTime: ['', Validators.required]
    });

    this.branchService.GetBranches().then((res: HttpResponse<IBranch[]>) => {
      this.branches = res.body;
    });
  }

  get firstName() {
    return this.detailsFormGroup.get('firstName')
  }
  get surname() {
    return this.detailsFormGroup.get('surname')
  }
  get phoneNumber() {
    return this.detailsFormGroup.get('phoneNumber')
  }
  get telephoneNumber() {
    return this.detailsFormGroup.get('telephoneNumber')
  }
  get email() {
    return this.detailsFormGroup.get('email')
  }
  get address() {
    return this.detailsFormGroup.get('address')
  }

  setValues() {
    this.booking.firstName = this.firstName.value;
    this.booking.surname = this.surname.value;
    this.booking.phoneNumber = this.phoneNumber.value;
    this.booking.telephoneNumber = this.telephoneNumber.value;
    this.booking.email = this.email.value;
    this.booking.address = this.address.value;
    this.booking.branch = this.selectedBranch;
    this.booking.treatment = this.selectedTreatment;
  }

  getTreatments() {
    this.treatmentService.GetTreatmentsByBranchId(this.selectedBranch.id).then((res: HttpResponse<ITreatment[]>) => {
      this.treatments = res.body;
    });
  }

  bookAppointment() {

    this.newBooking.firstName = this.booking.firstName
    this.newBooking.surname = this.booking.surname
    this.newBooking.phoneNumber = this.booking.phoneNumber
    this.newBooking.telephoneNumber = this.booking.telephoneNumber
    this.newBooking.email = this.booking.email
    this.newBooking.date = this.booking.date;
    this.newBooking.address = this.booking.address
    this.newBooking.branchId = this.booking.branch.id
    this.newBooking.treatmentId = this.booking.treatment.id

    this.bookingService.CreateBooking(this.newBooking).then((res: HttpResponse<number>) => {
      const dialogConfig: MatDialogConfig = new MatDialogConfig();
      dialogConfig.data = res;
      dialogConfig.disableClose = true;
  
      const dialogRef = this.dialog.open(ConfirmationDialogComponent, dialogConfig);

      dialogRef.afterClosed().subscribe(() => {
        this.router.navigate(['dashboard']);
      });
    });
  }

  dateChangeEvent(event: MatDatepickerInputEvent<Date>) {
    this.booking.date = event.value;
  }
}
