import { Routes } from '@angular/router';

export const coreRoutes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./layout/layout.component').then((m) => m.LayoutComponent),
    children: [
      {
        path: 'categories',
        loadChildren: () =>
          import('../module/module.route').then((m) => m.moduleRoutes),
      },
    ],
  },
];
