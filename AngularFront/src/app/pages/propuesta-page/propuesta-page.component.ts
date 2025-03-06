import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ObjetoService } from 'src/app/service/objeto.service';
import { propuestaModel } from '../../models/propuestaModel';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-propuesta-page',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './propuesta-page.component.html',
  styleUrls: ['./propuesta-page.component.css']
})
export class PropuestaPageComponent implements OnInit {
  objetoId: number | null = null;
  propuesta: propuestaModel = { id: 0, nombre: '', descripcion: '',tipo:'',estado:'', createDate: new Date() };

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private objetoService: ObjetoService
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.objetoId = +id;
        this.cargarPropuesta();
      }
    });
  }

  async cargarPropuesta() {
    if (this.objetoId) {
      const objetoData = await this.objetoService.getProductById(this.objetoId);
      if (objetoData) {
        this.propuesta = objetoData;
      }
    }
  }

  async actualizarPropuesta() {
    if (this.objetoId) {
      try {
        await this.objetoService.updateProduct(this.objetoId, this.propuesta);
        alert('Objeto actualizado correctamente.');
      } catch (error) {
        console.error('Error al actualizar el objeto', error);
        alert('Hubo un error al actualizar el objeto.');
      }
    }
  }

  async eliminarPropuesta() {
    if (this.objetoId) {
      const confirmacion = confirm('¿Estás seguro de que deseas eliminar este objeto?');
      if (confirmacion) {
        try {
          await this.objetoService.deleteProduct(this.objetoId);
          alert('Objeto eliminado correctamente.');
          this.location.back();
        } catch (error) {
          console.error('Error al eliminar el objeto', error);
          alert('Hubo un error al eliminar el objeto.');
        }
      }
    }
  }

  goBack() {
    this.location.back();
  }
}
