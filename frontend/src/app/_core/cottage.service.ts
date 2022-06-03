import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cottage } from '../_models/cottage';

@Injectable({
  providedIn: 'root'
})
export class CottageService {

  constructor(
    private http: HttpClient,
  ) { }

  public getCottages(): Observable<Cottage[]> {
    return this.http.get<Cottage[]>(`${environment.apiUrl}/cottages`);
  }

  public getCottage(id: string): Observable<Cottage> {
    return this.http.get<Cottage>(`${environment.apiUrl}/cottages/${id}`);
  }
}
