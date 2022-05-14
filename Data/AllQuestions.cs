/*using JoseTFG.Models;
using System;
using System.Collections.Generic;

namespace JoseTFG.Data
{
    class AllQuestions
    {
        public static List<Question> getSurvey()
        {
            List<Question> survey = new List<Question>();

            var q1 = "Durante el último año, he tenido tos";
            var q2 = "Durante el último año, he sacado flemas (sacar gargajos)";
            var q3 = "Durante el último año, he tenido falta de aire";
            var q4 = "Durante el último año, he tenido ataques de silbidos (ruidos en el pecho)";
            var q5 = "Durante el último año ¿cuántos ataques por problemas respiratorios tuvo que fueran graves o muy desagradables?";
            var q6 = "¿Cuánto le duró el peor de los ataques que tuvo por problemas respiratorios? (si no tuvo ningún ataque serio vaya directamente a la pregunta No. 7)";
            var q7 = "Durante el último año ¿cuántos días a la semana fueron buenos?";
            var q8 = "Si tiene silbidos en el pecho (bronquios), ¿son peores por la mañana? (si no tiene silbidos en los pulmones vaya directamente a la pregunta No. 9)";
            var q9 = "¿Cómo describiría usted su condición de los pulmones? Por favor, marque una sola de las siguientes frases:";
            var q10 = "Si ha tenido un trabajo con sueldo. Por favor marque una sola de las siguientes frases: (si no ha tenido un trabajo con sueldo vaya directamente a la pregunta No. 11)";
            var q11 = "A continuación, algunas preguntas sobre otras actividades que normalmente le pueden hacer sentir que le falta la respiración.Por favor, marque todas las respuestas que correspondan a cómo usted está actualmente";
            var q12 = "Algunas preguntas más sobre la tos y la falta de respiración. Por favor, marque todas las respuestas que correspondan a como está usted actualmente:";
            var q13 = "A continuación, algunas preguntas sobre otras consecuencias que sus problemas respiratorios le pueden causar. Por favor, marque todas las respuestas a cómo está usted en estos días: ";
            var q14 = "A continuación, algunas preguntas sobre su medicación. (Si no está tomando ningún medicamento, vaya directamente a la pregunta No. 15)";
            var q15 = "Estas preguntas se refieren a cómo sus problemas respiratorios pueden afectar sus actividades. Por favor, marque cierto sí usted cree que una o más partes de cada frase le describen si no, marque falso: ";
            var q16 = "Nos gustaría saber ahora cómo sus problemas respiratorios afectan normalmente su vida diaria. Por favor, marque cierto si aplica la frase a usted debido a sus problemas respiratorios:";
            var q17 = "A continuación ¿Podría marcar sólo una frase que usted crea que describe mejor cómo le afectan sus problemas respiratorios ?";

            var op1_1 = "La mayor parte de los días de la semana";
            var op1_2 = "Varios días a la semana";
            var op1_3 = "Unos pocos días a la semana";
            var op1_4 = "Sólo cuando tuve infección en los pulmones o bronquios";
            var op1_5 = "Nada en absoluto";

            var op5_1 = "Más de tres ataques";
            var op5_2 = "Tres ataques";
            var op5_3 = "Dos ataques";
            var op5_4 = "Un ataque";
            var op5_5 = "Ningún ataque";

            var op6_1 = "Una semana o más";
            var op6_2 = "De tres a seis días";
            var op6_3 = "Uno o dos días";
            var op6_4 = "Menos de un día";

            var op7_1 = "Ningún día fue bueno";
            var op7_2 = "De tres a seis días";
            var op7_3 = "Uno o dos días fueron buenos";
            var op7_4 = "Casi todos los días";
            var op7_5 = "Todos los días han sido buenos";

            var op8_1 = "No";
            var op8_2 = "Si";

            var op9_1 = "Es el problema más importante que tengo";
            var op9_2 = "Me causa bastantes problemas";
            var op9_3 = "Me causa pocos problemas";
            var op9_4 = "No me causa ningún problema";

            var op10_1 = "Mis problemas respiratorios me obligaron a dejar de trabajar";
            var op10_2 = "Mis problemas respiratorios me dificultan mi trabajo o me obligaron a cambiar de trabajo";
            var op10_3 = "Mis problemas respiratorios no afectan (o no afectaron) mi trabajo";

            var op11_1 = "Me falta la respiración estando sentado o incluso descansando";
            var op11_2 = "Me falta la respiración cuando me lavo o me visto";
            var op11_3 = "Me falta la respiración al caminar dentro de la casa";
            var op11_4 = "Me falta la respiración al caminar alrededor de la casa, sobre un terreno plano";
            var op11_5 = "Me falta la respiración al subir un tramo de escaleras";
            var op11_6 = "Me falta la respiración al caminar de subida";
            var op11_7 = "Me falta la respiración al hacer deportes o jugar";

            var op12_1 = "Me duele al toser";
            var op12_2 = "Me canso cuando toso";
            var op12_3 = "Me falta la respiración cuando hablo";
            var op12_4 = "Me falta la espiración cuando me agacho";
            var op12_5 = "La tos o la respiración interrumpen mi sueño";
            var op12_6 = "Fácilmente me agoto";

            var op13_1 = "La tos o la respiración me apenan en público";
            var op13_2 = "Mis problemas respiratorios son una molestia para mi familia, mis amigos o mis vecinos";
            var op13_3 = "Me asusto o me alarmo cuando no puedo respirar";
            var op13_4 = "Siento que no puedo controlar mis problemas respiratorios";
            var op13_5 = "No espero que mis problemas respiratorios mejoren";
            var op13_6 = "Por causa de mis problemas respiratorios me he convertido en una persona insegura o inválida";
            var op13_7 = "Hacer ejercicio no es seguro para mí";
            var op13_8 = "Cualquier cosa que hago me parece que es un esfuerzo excesivo";

            var op14_1 = "Mis medicamentos no me ayudan mucho";
            var op14_2 = "Me apena usar mis medicamentos en público";
            var op14_3 = "Mis medicamentos me producen efectos desagradables";
            var op14_4 = "Mis medicamentos afectan mucho mi vida";

            var op15_1 = "Me tardo mucho tiempo para lavarme o vestirme";
            var op15_2 = "No me puedo bañar o, me tardo mucho tiempo";
            var op15_3 = "Camino más despacio que los demás o, tengo que parar a descansar";
            var op15_4 = "Tardo mucho para hacer trabajos como las tareas domésticas o, tengo que parar a descansar";
            var op15_5 = "Para subir un tramo de escaleras, tengo que ir más despacio o parar";
            var op15_6 = "Si corro o camino rápido, tengo que parar o ir más despacio";
            var op15_7 = "Mis problemas respiratorios me dificultan hacer cosas tales como, caminar de subida, cargar cosas subiendo escaleras, caminar durante un buen rato, arreglar un poco el jardín, bailar o jugar boliche";
            var op15_8 = "Mis problemas respiratorios me dificultan hacer cosas tales como, llevar cosas pesadas, caminar a unos 7 kilómetros por hora, trotar, nadar, jugar tenis, escarbar en el jardín o en el campo";
            var op15_9 = "Mis problemas respiratorios me dificultan hacer cosas tales como, un trabajo manual muy pesado, correr, ir en bicicleta, nadar rápido o practicar deportes de competencia";

            var op16_1 = "No puedo hacer deportes o jugar";
            var op16_2 = "No puedo salir a distraerme o divertirme";
            var op16_3 = "No puedo salir de casa para ir de compras";
            var op16_4 = "No puedo hacer el trabajo de la casa";
            var op16_5 = "No puedo alejarme mucho de la cama o la silla";

            var op17_1 = "No me impiden hacer nada de lo que me gustaría hacer";
            var op17_2 = "Me impiden hacer una o dos cosas de las que me gustaría hacer";
            var op17_3 = "Me impiden hacer la mayoría de las cosas que me gustaría hacer";
            var op17_4 = "Me impiden hacer todo lo que me gustaría hacer";

            List<String> ops1 = new List<string>();
            ops1.Add(op1_1);
            ops1.Add(op1_2);
            ops1.Add(op1_3);
            ops1.Add(op1_4);
            ops1.Add(op1_5);

            List<String> ops2 = new List<string>();
            ops2.Add(op1_1);
            ops2.Add(op1_2);
            ops2.Add(op1_3);
            ops2.Add(op1_4);
            ops2.Add(op1_5);

            List<String> ops3 = new List<string>();
            ops3.Add(op1_1);
            ops3.Add(op1_2);
            ops3.Add(op1_3);
            ops3.Add(op1_4);
            ops3.Add(op1_5);

            List<String> ops4 = new List<string>();
            ops4.Add(op1_1);
            ops4.Add(op1_2);
            ops4.Add(op1_3);
            ops4.Add(op1_4);
            ops4.Add(op1_5);

            List<String> ops5 = new List<string>();
            ops5.Add(op5_1);
            ops5.Add(op5_2);
            ops5.Add(op5_3);
            ops5.Add(op5_4);
            ops5.Add(op5_5);

            List<String> ops6 = new List<string>();
            ops6.Add(op6_1);
            ops6.Add(op6_2);
            ops6.Add(op6_3);
            ops6.Add(op6_4);

            List<String> ops7 = new List<string>();
            ops7.Add(op7_1);
            ops7.Add(op7_2);
            ops7.Add(op7_3);
            ops7.Add(op7_4);
            ops7.Add(op7_5);

            List<String> ops8 = new List<string>();
            ops8.Add(op8_1);
            ops8.Add(op8_2);

            List<String> ops9 = new List<string>();
            ops9.Add(op9_1);
            ops9.Add(op9_2);
            ops9.Add(op9_3);
            ops9.Add(op9_4);

            List<String> ops10 = new List<string>();
            ops10.Add(op10_1);
            ops10.Add(op10_2);
            ops10.Add(op10_3);

            List<String> ops11 = new List<string>();
            ops11.Add(op11_1);
            ops11.Add(op11_2);
            ops11.Add(op11_3);
            ops11.Add(op11_4);
            ops11.Add(op11_5);
            ops11.Add(op11_6);
            ops11.Add(op11_7);

            List<String> ops12 = new List<string>();
            ops12.Add(op12_1);
            ops12.Add(op12_2);
            ops12.Add(op12_3);
            ops12.Add(op12_4);
            ops12.Add(op12_5);
            ops12.Add(op12_6);

            List<String> ops13 = new List<string>();
            ops13.Add(op13_1);
            ops13.Add(op13_2);
            ops13.Add(op13_3);
            ops13.Add(op13_4);
            ops13.Add(op13_5);
            ops13.Add(op13_6);
            ops13.Add(op13_7);
            ops13.Add(op13_8);

            List<String> ops14 = new List<string>();
            ops14.Add(op14_1);
            ops14.Add(op14_2);
            ops14.Add(op14_3);
            ops14.Add(op14_4);

            List<String> ops15 = new List<string>();
            ops15.Add(op15_1);
            ops15.Add(op15_2);
            ops15.Add(op15_3);
            ops15.Add(op15_4);
            ops15.Add(op15_5);
            ops15.Add(op15_6);
            ops15.Add(op15_7);
            ops15.Add(op15_8);
            ops15.Add(op15_9);

            List<String> ops16 = new List<string>();
            ops16.Add(op16_1);
            ops16.Add(op16_2);
            ops16.Add(op16_3);
            ops16.Add(op16_4);
            ops16.Add(op16_5);

            List<String> ops17 = new List<string>();
            ops17.Add(op17_1);
            ops17.Add(op17_2);
            ops17.Add(op17_3);
            ops17.Add(op17_4);

            survey.Add(new QuestionOneSolution(q1, ops1, false));
            survey.Add(new QuestionOneSolution(q2, ops2, false));
            survey.Add(new QuestionOneSolution(q3, ops3, false));
            survey.Add(new QuestionOneSolution(q4, ops4, false));
            survey.Add(new QuestionOneSolution(q5, ops5, false));
            survey.Add(new QuestionOneSolution(q6, ops6, true));
            survey.Add(new QuestionOneSolution(q7, ops7, false));
            survey.Add(new QuestionOneSolution(q8, ops8, true));
            survey.Add(new QuestionOneSolution(q9, ops9, false));
            survey.Add(new QuestionOneSolution(q10, ops10, true));
            survey.Add(new QuestionMultipleSolutions(q11, ops11, false));
            survey.Add(new QuestionMultipleSolutions(q12, ops12, false));
            survey.Add(new QuestionMultipleSolutions(q13, ops13, false));
            survey.Add(new QuestionMultipleSolutions(q14, ops14, false));
            survey.Add(new QuestionMultipleSolutions(q15, ops15, false));
            survey.Add(new QuestionMultipleSolutions(q16, ops16, false));
            survey.Add(new QuestionOneSolution(q17, ops17, false));

            return survey;
        }
    }
}*/