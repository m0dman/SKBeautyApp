import { Branch } from "../branch/branch";
import { Treatment } from "../treatment/treatment";

export interface IBooking {
  id: number;
  firstName: string;
  surname: string;
  address: string;
  email: string;
  telephoneNumber: string;
  phoneNumber: string;
  date: Date;
  branch: Branch;
  treatment: Treatment;
}
