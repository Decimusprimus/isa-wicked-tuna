import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cottage } from '../_models/cottage';
import { CottageReservation } from '../_models/cottageReservation';

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

  public getFirstCottageImage(cottage: Cottage) {
    return `${environment.apiUrl}/cottages/${cottage.id}/image`;
  }

  public getCottageImageForName(cottage: Cottage, image: string) {
    return `${environment.apiUrl}/cottages/${cottage.id}/images/${image}`;
  }

  public getCottageImages(id: string): Observable<string[]> {
    return this.http.get<string[]>(`${environment.apiUrl}/cottages/${id}/images`);
  }

  public crateReservation(reservation: CottageReservation, cottage: Cottage) : Observable<CottageReservation> {
    return this.http.post<CottageReservation>(`${environment.apiUrl}/cottages/${cottage.id}/reservation`, reservation);
  }
  
 
}
