import { Routes } from '@angular/router';

export const coreRoutes: Routes = [
  {
    path: '',
    loadComponent: () => import('./layout/layout.component').then((m) => m.LayoutComponent),
  },
];
