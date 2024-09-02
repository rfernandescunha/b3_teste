import { Component,Inject, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-cdb-component',
  templateUrl: './cdb.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CdbComponent {
  public ValorBruto: number | undefined = 0.0;
  public ValorLiquido: number | undefined = 0.0;
  public valorInicial: number | undefined;
  public qtdMeses: number | undefined;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private cdRef: ChangeDetectorRef) {}

    enviarDados() {
      const body = {
        valorInicial: this.valorInicial,
        qtdMeses: this.qtdMeses
      };

      const headers = new HttpHeaders().set('Content-Type', 'application/json');
  
      this.http.post(this.baseUrl + 'cdbcalculator', body, { headers }).subscribe(
        (data: any) => {
          this.ValorBruto = data.valorBruto;
          this.ValorLiquido = data.valorLiquido;
          this.cdRef.detectChanges(); 
        },
        (error: any) => {
          console.error('Erro:', error);
        }
      );
    }

    validarCampos(): boolean {
      return this.qtdMeses === undefined || this.qtdMeses === null || this.qtdMeses <= 0 ||
             this.valorInicial === undefined || this.valorInicial === null || this.valorInicial === 0;
    }
  

   }

interface CdbCalculator {
  ValorBruto: number;
  ValorLiquido: number;
}
