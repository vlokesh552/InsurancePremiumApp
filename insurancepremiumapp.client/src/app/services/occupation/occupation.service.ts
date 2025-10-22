import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Occupation } from '../../models/occupation';

@Injectable({
  providedIn: 'root'
})
export class OccupationService {
  private apiUrl = 'https://localhost:7144/api/occupation';

  constructor(private http: HttpClient) {}

  
  getOccupations(): Observable<Occupation[]> {
    const defaultOccupations: Occupation[] = [
    { id: 1, name: 'Cleaner-test'} ,
    { id: 2, name: 'Doctor-test'}
  ];

    return this.http.get<Occupation[]>(this.apiUrl).pipe(
    catchError(error => {
      console.error('API call failed, returning default occupations', error);
      return of(defaultOccupations);
    }));
  }
}
