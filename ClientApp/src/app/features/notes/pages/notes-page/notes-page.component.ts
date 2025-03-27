import { Component } from '@angular/core';
import { NotesService } from '../../services/notes.service';
import { Note } from '../../models/note';
import { RouterModule } from '@angular/router';
import { NoteListComponent } from '../../components/note-list/note-list.component';

@Component({
  selector: 'app-notes-page',
  standalone: true,
  imports: [RouterModule, NoteListComponent],
  templateUrl: './notes-page.component.html',
  styleUrl: './notes-page.component.css',
})
export class NotesPageComponent {
  notes: Note[] = [];

  constructor(private notesService: NotesService) {
    this.fetchNotes();
  }

  fetchNotes() {
    this.notesService.getAll().subscribe((data) => {
      this.notes = data;
    });
  }
}
