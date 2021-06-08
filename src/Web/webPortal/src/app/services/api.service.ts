import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { SettingsProvider } from './settingsprovider';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  protected apiServer = environment.apiURL;
  constructor(private http: HttpClient) {}

  // Formats the errors that come from API requests and outputs them to the console.
  private formatErrors(error: any) {
    return throwError(error.error);
  }

  // Used to get data from the API.
  async get<T>(url: string, responseType: any = null): Promise<HttpResponse<T>> {
    if (responseType !== null) {
      return this.http
        .get<T>(`${this.apiServer}${url}`, {
          responseType: responseType as 'json',
          observe: 'response',
        })
        .pipe()
        .toPromise();
    } else {
      return this.http
        .get<T>(`${this.apiServer}${url}`, {
          observe: 'response',
        })
        .pipe()
        .toPromise();
    }
  }

  //Used to pass objects to the API for use elsewhere, not for inserting. Replace used on json to from _ when handling private variables.
  async post(url: string, body: Object = {}): Promise<any> {
    let headers = new HttpHeaders();
    return this.http
      .post(`${this.apiServer}${url}`, JSON.stringify(body), {
        headers: headers = headers.set('Content-Type', 'application/json').set('Strict-Transport-Sercurity', 'max-age=31536000; includeSubDomains')
      })
      .pipe()
      .toPromise();
  }


  // Used to pass data to the API to be inserted into the database. Replace used on json to from _ when handling private variables.
  async put<T>(url: string, body: Object = {}): Promise<HttpResponse<T>> {
    return this.http
      .put<T>(`${this.apiServer}${url}`, JSON.stringify(body), {
        observe: 'response',
      })
      .pipe()
      .toPromise();
  }

  // Used to pass an id to the API to then allow for deletion in the database.
  async delete<T>(url: string): Promise<HttpResponse<T>> {
    return this.http
      .delete<T>(`${this.apiServer}${url}`, {
        observe: 'response',
      })
      .pipe()
      .toPromise();
  }
}
