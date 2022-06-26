import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactApiService {

  readonly contactApiUrl = 'https://localhost:7251/api';

  constructor(private http: HttpClient) { }

  // ContactCategories

  getContactCategoriesList(): Observable<any[]> {
    return this.http.get<any>(this.contactApiUrl + '/ContactCategories');
  }

  // Contacts

  getContactList(): Observable<any[]> {
    return this.http.get<any>(this.contactApiUrl + '/Contacts');
  }

  addContact(data: any) {
    return this.http.post(this.contactApiUrl + '/Contacts', data);
  }

  updateContact(id: number | string, data: any) {
    return this.http.put(this.contactApiUrl + `/Contacts/${id}`, data);
  }

  deleteContact(id: number | string) {
    return this.http.delete(this.contactApiUrl + `/Contacts/${id}`);
  }

  // ContactSubCategories

  getContactSubCategoriesList(): Observable<any[]> {
    return this.http.get<any>(this.contactApiUrl + '/ContactSubCategories');
  }

  // Users

  updateUsers(id: number | string, data: any) {
    return this.http.put(this.contactApiUrl + `/Users/${id}`, data);
  }
}
