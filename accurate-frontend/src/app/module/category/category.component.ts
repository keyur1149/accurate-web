import { Component } from '@angular/core';
import { CategoryCardComponent } from '../category-card/category-card.component';
import { category } from '../interfaces/category.interface';
import { CommonModule } from '@angular/common';
import { CategoryService } from '../services/category.service';
import { ApiResponse } from '../../shared/interfaces/api-response.interface';
import { HttpErrorResponse } from '@angular/common/http';
import { SnackBarService } from '../../shared/services/snackbar.service';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [CategoryCardComponent, CommonModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css',
})
export class CategoryComponent {
  categories: category[] = [];
  constructor(
    private categoryService: CategoryService,
    private snackbar: SnackBarService
  ) {}
  ngOnInit(): void {
    this.loadCategories();
  }
  private loadCategories() {
    this.categoryService.getAllCategory().subscribe({
      next: (res: ApiResponse<category[]>) => {
        if (res.isSuccess && res.result) {
          this.categories = res.result;
        }
      },
      error: (error) => {
        const errorResponse: ApiResponse<category[]> = error.error;
        if (errorResponse.statusCode == 400) {
          this.snackbar.Error(error.error.errorMessages);
        } else if (errorResponse.statusCode == 500) {
          this.snackbar.Error('Sorry,Something went wrong!!');
        }
      },
    });
  }
}
