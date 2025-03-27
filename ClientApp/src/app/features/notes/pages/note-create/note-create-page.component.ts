import { Component } from '@angular/core';
import { NoteFormComponent } from '../../components/note-form/note-form.component';
import { NotesService } from '../../services/notes.service';
import { Router } from '@angular/router';
import { Note } from '../../models/note';

@Component({
  selector: 'app-note-create-page',
  standalone: true,
  imports: [NoteFormComponent],
  templateUrl: './note-create-page.component.html',
  styleUrl: './note-create-page.component.css',
})
export class NoteCreatePageComponent {
  constructor(private notesService: NotesService, private router: Router) {}

  createNote(note: Omit<Note, 'id'>) {
    this.notesService.createNote(note).subscribe(() => {
      this.router.navigate(['/notes']);
    });
  }
}
