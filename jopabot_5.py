import telebot
import json
import random
import datetime
import time
import requests
import os
from telebot import types
bot = telebot.TeleBot(TOKEN)

@bot.message_handler(func=lambda message: str(message.chat.id) not in json.load(open("data.txt", "r"))[0], commands=['vanek10'])
def new_chat_id(message):
   with open("data.txt", "r") as f:
      data = json.load(f)

   data[0][str(message.chat.id)] = dict()
   with open("data.txt", "w") as f:
      json.dump(data, f, indent=4, sort_keys=True)
   start_message(message)

@bot.message_handler(func=lambda message: str(message.from_user.first_name) not in json.load(open("data.txt", "r"))[0][str(message.chat.id)], commands=['vanek10'])
def start_message(message):
   bot.reply_to(message, str(message.from_user.first_name) + ", ты зарегистрировался в игре \"самые длинные уши\"!")
   with open("data.txt", "r") as f:
      data = json.load(f)
            
   lenght = random.randint(1, 10)            
   time = datetime.datetime.now()
   data[0][str(message.chat.id)][str(message.from_user.first_name)] = dict()
   data[0][str(message.chat.id)][str(message.from_user.first_name)]["lenght"] = lenght
   data[0][str(message.chat.id)][str(message.from_user.first_name)]["time to play"] = time.day
   data[0][str(message.chat.id)][str(message.from_user.first_name)]["race"] = "уши"
   bot.reply_to(message, str(message.from_user.first_name) + ", твои уши выросли на "  + str(lenght) + " см.\nТеперь их длина: " + 
                  str(data[0][str(message.chat.id)][str(message.from_user.first_name)]["lenght"]) + " см.\nПродолжай играть через " + str(abs(datetime.datetime.now().hour - 24)) + " ч.")
          
   with open("data.txt", "w") as f:
      json.dump(data, f, indent=4, sort_keys=True)
            
@bot.message_handler(commands=['vanek10'])
def play_message(message):
   with open("data.txt", "r") as f:
      data = json.load(f)
         
   time = datetime.datetime.now()
   time_user = data[0][str(message.chat.id)][str(message.from_user.first_name)]["time to play"]
   lenght_user = data[0][str(message.chat.id)][str(message.from_user.first_name)]["lenght"]
   if time.day > time_user:
      result = random.choice([True, True, False])
      if result:
         lenght = random.randint(1, 15)
         condition = ", твои уши выросли на " + str(lenght) + " см."
      else:
         if lenght_user >= 15:
            lenght = random.randint(-15, 0)
         elif lenght_user == 0:
            lenght = random.randint(0, 15)
         else:
            lenght = random.randint(-lenght_user, 0)
         if lenght == 0:
            condition = ", твои уши остались такими же."
         else:
            condition = ", твои уши укоротились на " + str(abs(lenght)) + " см."
                
      data[0][str(message.chat.id)][str(message.from_user.first_name)]["lenght"] += lenght
      data[0][str(message.chat.id)][str(message.from_user.first_name)]["time to play"] = time.day
                   
      if lenght == 0:
         bot.reply_to(message, str(message.from_user.first_name) + condition)
      else:
         bot.reply_to(message, str(message.from_user.first_name) + condition + "\nТеперь их длина: " +
                        str(data[0][str(message.chat.id)][str(message.from_user.first_name)]["lenght"]) + " см.\nПродолжай играть через " + str(abs(datetime.datetime.now().hour - 24)) + " ч.")
      with open("data.txt", "w") as f:
         json.dump(data, f, indent=4, sort_keys=True)      
               
   else:
      bot.reply_to(message, str(message.from_user.first_name) + ", ты сегодня уже играл\nПродолжай играть через " + str(abs(datetime.datetime.now().hour - 24)) + " ч.!")
            
@bot.message_handler(commands=['top'])
def top_message(message):
   with open("data.txt", "r") as f:
      data = json.load(f)
            
   dic = dict()
   lst = list()
   for key, value in data[0][str(message.chat.id)].items():
      dic[key] = value["lenght"]
         
   count = 1
   for i in sorted(dic, key=dic.get, reverse=True):
      lst.append(str(count) + ". " + i + " - "  + str(data[0][str(message.chat.id)][i]["lenght"]) + " см")
      count += 1
            
   bot.send_message(message.chat.id, "\n".join(lst))
         
@bot.message_handler(commands=['help'])
def help_message(message):
   bot.send_message(message.chat.id, "Игра \"самые длинные уши\"\n\n/vanek10 - сыграть в игру\n/top - топ игроков\n/battle - вызвать игрока на поединок (открывается при 15 см)\n/nevanek10 - выйти из игры")


@bot.message_handler(func=lambda message: str(message.from_user.first_name) in json.load(open("data.txt", "r"))[0][str(message.chat.id)], commands=['nevanek10'])
def end_message(message):
   bot.reply_to(message, str(message.from_user.first_name) + ", ты вышел из игры!")
   with open("data.txt", "r") as f:
      data = json.load(f)

@bot.message_handler(func=lambda message: str(message.from_user.first_name) in json.load(open("data.txt", "r"))[0][str(message.chat.id)], commands=['nevanek10'])
def end_message(message):
   bot.reply_to(message, str(message.from_user.first_name) + ", ты вышел из игры!")
   with open("data.txt", "r") as f:
      data = json.load(f)
      
   data[0][str(message.chat.id)].pop(str(message.from_user.first_name))
         
   with open("data.txt", "w") as f:
      json.dump(data, f, indent=4, sort_keys=True)
    
@bot.message_handler(func=lambda message: str(message.from_user.first_name) in json.load(open("data.txt", "r"))[0][str(message.chat.id)], commands=['battle'])
def battle_message(message):
   with open("data.txt", "r") as f:
      data = json.load(f)
      
   time = datetime.datetime.now()
   user = data[0][str(message.chat.id)][str(message.from_user.first_name)]
   
   if data[0][str(message.chat.id)][str(message.from_user.first_name)]["lenght"] >= 15:
      if ("time to battle" not in user) or (time.day > user["time to battle"]):
         keyboard = types.InlineKeyboardMarkup(row_width=1)
         dic = dict()
         for key, value in data[0][str(message.chat.id)].items():
            dic[key] = value["lenght"]
               
         for i in sorted(dic, key=dic.get, reverse=True):
            
            if i != message.from_user.first_name:
               keyboard.add(types.InlineKeyboardButton(text=i + " - " + str(data[0][str(message.chat.id)][i]["lenght"]), callback_data=i + " " + str(message.chat.id) + " " + str(message.message_id)))
      
         bot.send_message(message.from_user.id, 'Кого хочешь вызвать на батл?', reply_markup=keyboard)
         
         data[0][str(message.chat.id)][str(message.from_user.first_name)]["time to battle"] = time.day
         with open("data.txt", "w") as f:
            json.dump(data, f, indent=4, sort_keys=True)
      else:
         bot.reply_to(message, str(message.from_user.first_name) + ", ты устал, отдохни еще " + str(abs(datetime.datetime.now().hour - 24)) + " ч.!")
   else:
      bot.reply_to(message, str(message.from_user.first_name) + ', отрасти уши!')
   
   
@bot.callback_query_handler(func=lambda call: True)
def callback_inline(call):
   bot.edit_message_text(chat_id=call.message.chat.id, message_id=call.message.message_id, text="Битва начинается...")
   call_data = call.data.split()
   bot.send_message(call.message.chat.id, "Ты выбрал " + str(call_data[0]))
   bot.send_message(int(call_data[1]), str(call.message.chat.first_name) + " вызвал на дуэль " + str(call_data[0]) + "!")
   
   with open("data.txt", "r") as f:
      data = json.load(f)
   
   lenght1 = data[0][str(call_data[1])][str(call.message.chat.first_name)]["lenght"]
   lenght2 = data[0][str(call_data[1])][str(call_data[0])]["lenght"] 

   damage = random.choice([0.1, 0.7, 0.75, 0.8, 0.9, 0.95, 1.0, 1.1, 1.7, 1.75, 1.8, 1.9, 1.95])

   if damage > 1:
      damage_enemy = round(lenght2 * (damage - 1))
      bot.send_message(call.message.chat.id, "Поздравляю! Ты выиграл битву\nТы нанес " + str(lenght2 - damage_enemy) + " урона противнику!")

      data[0][str(call_data[1])][str(call_data[0])]["lenght"] = damage_enemy
      data[0][str(call_data[1])][str(call.message.chat.first_name)]["lenght"] = lenght1 + (lenght2 - damage_enemy)
      
      time.sleep(3)
      if damage >= 1.8:
         bot.send_message(int(call_data[1]), str(call.message.chat.first_name) + " использовал ушной вихрь, тем самым поцарапав ухо " +
                          str(call_data[0]) + " на " + str(lenght2 - damage_enemy) + " урона!\nПобедитель - " + str(call.message.chat.first_name))
      elif 1.7 <= damage < 1.8:
         bot.send_message(int(call_data[1]), str(call_data[0]) + " совершил серьезную ошибку, подставив левое ухо, и " + str(call.message.chat.first_name) + ", воспользовавшись этим, отсек часть уха и нанес " +
                          str(lenght2 - damage_enemy) + " урона!\nПобедитель - " + str(call.message.chat.first_name))
      elif damage == 1.1:
         bot.send_message(int(call_data[1]), str(call.message.chat.first_name) + " использовал все свои навыки и точным ударом нанес сокрушительные " + 
                          str(lenght2 - damage_enemy) + " урона!\nПобедитель - " + str(call.message.chat.first_name))
   elif damage < 1:
      damage_enemy = round(lenght1 * damage)
      bot.send_message(call.message.chat.id, "К сожалению, ты проиграл битву (\nПротивник нанес тебе " + str(lenght1 - damage_enemy) + " урона!")

      data[0][str(call_data[1])][str(call.message.chat.first_name)]["lenght"] = damage_enemy
      data[0][str(call_data[1])][str(call_data[0])]["lenght"] = lenght2 + (lenght1 - damage_enemy)
      
      time.sleep(3)
      if 0.8 <= damage < 1:
         bot.send_message(int(call_data[1]), str(call_data[0]) + " использовал ушной вихрь, тем самым поцарапав ухо " +
                          str(call.message.chat.first_name) + " на " + str(lenght1 - damage_enemy) + " урона!\nПобедитель - " + str(call_data[0]))
      elif 0.7 <= damage < 0.8:
         bot.send_message(int(call_data[1]), str(call.message.chat.first_name) + " совершил серьезную ошибку, подставив левое ухо, и " + str(call_data[0]) + ", воспользовавшись этим, отсек часть уха и нанес " +
                          str(lenght1 - damage_enemy) + " урона!\nПобедитель - " + str(call_data[0]))
      elif damage == 0.1:
         bot.send_message(int(call_data[1]), str(call_data[0]) + " использовал все свои навыки и точным ударом нанес сокрушительные " + 
                          str(lenght1 - damage_enemy) + " урона!\nПобедитель - " + str(call_data[0]))
   else:
      bot.send_message(call.message.chat.id, "Ничья!")
      bot.send_message(int(call_data[1]), "Ничья!\nВсе уши остались целыми.")
      
   with open("data.txt", "w") as f:
      json.dump(data, f, indent=4, sort_keys=True)


if __name__ == '__main__':
   bot.polling(none_stop=True)