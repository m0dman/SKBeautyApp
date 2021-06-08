import { ICreateBooking } from "../interfaces/icreateBooking";

export class CreateBooking  implements ICreateBooking {
  firstName: string = "";
  surname: string = "";
  address: string = "";
  email: string = "";
  telephoneNumber: string = "";
  phoneNumber: string = "";
  date: Date = new Date();
  time: string = "";
  branchId: number;
  treatmentId: number;
}
