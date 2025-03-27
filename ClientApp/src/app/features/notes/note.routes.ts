import { Routes } from '@angular/router';

export const notesRoutes: Routes = [
  {
    path: 'notes',
    children: [
      {
        path: '',
        loadComponent: () =>
          import('./pages/notes-page/notes-page.component').then(
            (m) => m.NotesPageComponent
          ),
      },
      {
        path: 'create',
        loadComponent: () =>
          import('./pages/note-create/note-create-page.component').then(
            (m) => m.NoteCreatePageComponent
          ),
      },
      {
        path: ':id',
        loadComponent: () =>
          import('./pages/note-detail/note-details-page.component').then(
            (m) => m.NoteDetailsComponent
          ),
      },
      {
        path: ':id/edit',
        loadComponent: () =>
          import('./pages/note-edit/note-edit-page.component').then(
            (m) => m.NoteEditComponent
          ),
      },
    ],
  },
];
