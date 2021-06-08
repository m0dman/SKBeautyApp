import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpResponse } from '@angular/common/http';
import { Branch } from '../models/branch/branch';

@Injectable({
  providedIn: 'root'
})
export class BranchService {
  public api_url_tag: string;

  constructor(private apiService: ApiService) {
    this.api_url_tag = 'branch';
  }

  GetBranches(): Promise<HttpResponse<Branch[]>> {
    return this.apiService.get<Branch[]>(`${this.api_url_tag}/Get/`);
  }

  GetBranchById(id: number): Promise<HttpResponse<Branch>> {
    return this.apiService.get<Branch>(`${this.api_url_tag}/GetBranch/${id}`);
  }
}
