import { Routes } from '@angular/router';
import { notesRoutes } from './features/notes/note.routes';

export const routes: Routes = [
  { path: '', redirectTo: '/notes', pathMatch: 'full' },
  ...notesRoutes,
];
