import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Note } from '../../models/note';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-note-item',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './note-item.component.html',
  styleUrl: './note-item.component.css',
})
export class NoteItemComponent {
  @Input() note!: Note;
  @Output() onDelete = new EventEmitter<string>();

  playSound() {
    const audio = new Audio('./assets/beep.mp3');
    audio.currentTime = 0;
    audio.play().catch((e) => console.log('Audio play failed:', e));
  }
}
