import { Routes } from '@angular/router';

export const moduleRoutes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./category/category.component').then((m) => m.CategoryComponent),
  }
];
