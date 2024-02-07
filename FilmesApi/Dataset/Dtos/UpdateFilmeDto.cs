﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dataset.Dtos
{
    public class UpdateFilmeDto
    {

        [Required(ErrorMessage = "O titulo do filme é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O gênero do filme é obrigatório")]
        [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50")]
        public string Genero { get; set; }

        [Required]
        [Range(70, 600, ErrorMessage = "A duração do filme dever ser 70 e 600")]
        public int Duracao { get; set; }


    }
}
