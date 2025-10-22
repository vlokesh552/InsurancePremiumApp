import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          let errorMessage = 'An unknown error occurred';

          if (error.error instanceof ErrorEvent) {
            // Client-side or network error
            errorMessage = `Client-side error: ${error.error.message}`;
          } else {
            // Server-side error
            if (error.error && typeof error.error === 'string') {
              errorMessage = error.error;
            } else if (error.error && error.error.message) {
              errorMessage = error.error.message;
            } else {
              errorMessage = `Server returned code ${error.status}, message: ${error.message}`;
            }
          }

          // Optionally log the error to an external service here
          return throwError(() => new Error(errorMessage));
        })
      );
  }
}
