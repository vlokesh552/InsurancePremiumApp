import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { PremiumRequest } from '../../models/PremiumRequest';

@Injectable({
  providedIn: 'root'
})
export class UserPremiumService {
  private apiUrl = 'https://localhost:7144/api/premium/calculate'; 
  
    constructor(private http: HttpClient) {
    }

  calculatePremium(request: PremiumRequest): Observable<{ monthlyPremium: number }>
  {
    return this.http.post<{ monthlyPremium: number }>(this.apiUrl, request).pipe(
      catchError(error => {
        console.error('API call failed, returning default premium', error);
        return of({ monthlyPremium: 0 });
      })
    );
  }
}
