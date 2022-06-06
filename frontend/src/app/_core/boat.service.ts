import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Boat } from '../_models/boat';
import { BoatReservation } from '../_models/boatResrvation';

@Injectable({
  providedIn: 'root'
})
export class BoatService {

  constructor(
    private http: HttpClient,
  ) { }

  public getBoats(): Observable<Boat[]> {
    return this.http.get<Boat[]>(`${environment.apiUrl}/boats`);
  }

  public getBoat(id: string): Observable<Boat> {
    return this.http.get<Boat>(`${environment.apiUrl}/boats/${id}`);
  }

  public getFirstBoatImage(boat: Boat) {
    return `${environment.apiUrl}/boats/${boat.id}/image`;
  }

  public getBoatImageForName(boat: Boat, image: string) {
    return `${environment.apiUrl}/boats/${boat.id}/images/${image}`;
  }

  public getBoatImages(id: string): Observable<string[]> {
    return this.http.get<string[]>(`${environment.apiUrl}/boats/${id}/images`);
  }

  public createReservation(reservation: BoatReservation, boat: Boat): Observable<BoatReservation> {
    return this.http.post<BoatReservation>(`${environment.apiUrl}/boats/${boat.id}/reservation`, reservation);
  }

  public getSpecialOffers() : Observable<BoatReservation[]> {
    return this.http.get<BoatReservation[]>(`${environment.apiUrl}/boats/special-offers`);
  }
}
