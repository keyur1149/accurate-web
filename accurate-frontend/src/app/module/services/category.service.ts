import { Injectable } from '@angular/core';
import { APIInterfaceService } from '../../shared/services/api-interface.service';
import { ApiResponse } from '../../shared/interfaces/api-response.interface';
import { category } from '../interfaces/category.interface';
import { Observable } from 'rxjs';
import { API_ROUTES } from '../../shared/common/API_ROUTES';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private apiInterfaceService: APIInterfaceService) {}
  getAllCategory(): Observable<ApiResponse<category[]>> {
    return this.apiInterfaceService.get<category[]>(
      API_ROUTES.CATEGORY.GET_ALL
    );
  }
}
