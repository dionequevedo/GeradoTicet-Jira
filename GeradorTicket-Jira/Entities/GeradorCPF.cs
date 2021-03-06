﻿using System;
using System.Collections.Generic;

namespace GeradorTicket_Jira.Entities
{
    class GeradorCPF
    {

        public int Numero { get; private set; }

        public GeradorCPF()
        {
        }

        public string GeraCPF()
        {
            Random cpf = new Random();
            List<int> digCpf = new List<int>();
            List<int> multCpf = new List<int> { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            List<int> primeiroResultCpf = new List<int>();
            List<int> segundoResultCpf = new List<int>();
            int segundoDigito = 0;
            string numCPF = "";
            for(int i = 0; i < 9; i++)
            {
                int primeiroDigito = 0;
                int primeiraSoma = 0;

                if(i < 9)
                    digCpf.Add(cpf.Next(0, 9));     /* Adiciona os primeiros 9 dígitos aleatórios */

                if (i == 8)          /* Valida se já possui os 9 primeiros dígitos */
                {
                    for(int y = 0; y < 9; y++)
                    {
                        primeiroResultCpf.Add(digCpf[y] * multCpf[y+1]);
                        if(y == 8)
                        {
                            foreach (int valor in primeiroResultCpf)
                            {
                                primeiraSoma += valor;
                            };

                            int v = primeiraSoma % 11;
                            primeiraSoma = v;    /* Calcula o resto da divisão da soma da primeira etapa por 11 */

                            if (primeiraSoma < 2)
                            {
                                primeiroDigito = 0;
                            }
                            else if (primeiraSoma >= 2 && primeiraSoma < 11)
                            {
                                primeiroDigito = 11 - primeiraSoma;
                            }
                        }
                    }

                    digCpf.Add(primeiroDigito);
                }
                
                if (digCpf.Count == 10)  /* Valida se já possui os 10 primeiros dígitos */
                {
                    for (int t = 0; t < 10; t++)
                    {
                        int segundaSoma = 0;
                        segundoResultCpf.Add(digCpf[t] * multCpf[t]);
                        if (t == 9) 
                        {
                            foreach (int valor in segundoResultCpf)
                            {
                                segundaSoma += valor;
                            };

                            int x = segundaSoma % 11;
                            segundaSoma = x;    /* Calcula o resto da divisão da soma da segunda etapa por 11 */

                            if (segundaSoma < 2)
                            {
                                segundoDigito = 0;
                            }
                            else if (segundaSoma >= 2 && segundaSoma < 11)
                            {
                                segundoDigito = 11 - segundaSoma;
                            }
                        }
                    }                    
                }
            }

            digCpf.Add(segundoDigito);

            foreach(int num in digCpf)
            {
                numCPF += num.ToString();
            }
            
            
            return numCPF;
        }
    }
}
