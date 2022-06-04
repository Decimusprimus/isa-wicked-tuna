import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Boat } from '../_models/boat';

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

}
