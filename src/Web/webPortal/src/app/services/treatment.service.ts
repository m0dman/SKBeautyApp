import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpResponse } from '@angular/common/http';
import { Treatment } from '../models/treatment/treatment';

@Injectable({
  providedIn: 'root'
})
export class TreatmentService {
  public api_url_tag: string;

  constructor(private apiService: ApiService) {
    this.api_url_tag = 'treatment';
  }

  GetTreatments(): Promise<HttpResponse<Treatment[]>> {
    return this.apiService.get<Treatment[]>(`${this.api_url_tag}/Get/`);
  }

  GetTreatmentById(id: number): Promise<HttpResponse<Treatment>> {
    return this.apiService.get<Treatment>(`${this.api_url_tag}/GetTreatment/${id}`);
  }

  GetTreatmentsByBranchId(branchID: number): Promise<HttpResponse<Treatment[]>> {
    return this.apiService.get<Treatment[]>(`${this.api_url_tag}/GetTreatmentsByBranchID/${branchID}`);
  }

}
