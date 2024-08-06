import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'access-denied',
    loadComponent: () =>
      import('../app/core/access-denied/access-denied.component').then(
        (m) => m.AccessDeniedComponent
      ),
  },
  {
    path: '',
    loadChildren: () => import('./core/core.route').then((m) => m.coreRoutes),
  },
  {
    path: '**',
    loadComponent: () =>
      import('./core/page-not-found/page-not-found.component').then(
        (p) => p.PageNotFoundComponent
      ),
  },
];
