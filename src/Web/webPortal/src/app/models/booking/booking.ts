import { Branch } from '../branch/branch';
import { IBooking } from '../interfaces/ibooking';
import { Treatment } from '../treatment/treatment';

export class Booking  implements IBooking {
  id: number = 0;
  firstName: string = "";
  surname: string = "";
  address: string = "";
  email: string = "";
  telephoneNumber: string = "";
  phoneNumber: string = "";
  date: Date = new Date();
  branch: Branch = new Branch();
  treatment: Treatment = new Treatment();
}
