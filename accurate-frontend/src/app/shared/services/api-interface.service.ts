import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
 
import { Observable } from 'rxjs';
import { ApiResponse } from '../interfaces/api-response.interface';
import { environment } from '../../../environment';
 
@Injectable({
  providedIn: "root",
})
export class APIInterfaceService{
    constructor(private http: HttpClient) { }
 
    get<T>(url:string, params? : HttpParams):Observable<ApiResponse<T>>{
        return this.http.get<ApiResponse<T>>(`${environment.baseUrl}${url}`,{params});
    }
 
    post<T>(url:string,data:any):Observable<ApiResponse<T>>{
        return this.http.post<ApiResponse<T>>(`${environment.baseUrl}${url}`,data);
    }
 
    put<T>(url:string,data:any):Observable<ApiResponse<T>>{
        return this.http.put<ApiResponse<T>>(`${environment.baseUrl}${url}`,data);
    }
 
    delete<T>(url:string):Observable<ApiResponse<T>>{
        return this.http.delete<ApiResponse<T>>(`${environment.baseUrl}${url}`);
    }
 
}