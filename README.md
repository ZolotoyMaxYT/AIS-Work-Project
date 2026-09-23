# АИС

## Основное
Все бизнес-функции возвращают статус результата работы, обычно это "удачно" (`Successful`) и "неудачно" (всё остальное)
 * Результаты бизнес-функций:
	* enum `IsExistResult` :
		* `IsExist` - Мод уже существует, 
		* `Successful` - Функция успешно выполнена;
	* enum `IsNotExistResult` :
		* `IsNotExist` - Мод/сборка не существует, 
		* `Successful` - Функция успешно выполнена;
	* enum `InModPackResult` : 
		* `IsNotExist` - Мод не существует, 
		* `InModPack` - Мод уже в сборке,
		* `Successful` - Функция успешно выполнена;
	* enum `NotInModPackResult` :
		* `IsNotExist` - Мод не существует, 
		* `NotInModPack` - Мода нет в сборке,
		* `Successful` - Функция успешно выполнена.

---

## Доступные функции:
 * Создать: `[IsExistResult] Logic.Create(...данные)`;
 * Удалить: `[IsNotExistResult] Logic.Delete(ID сущности)`;
 * Прочитать: `[IsNotExistResult] Logic.Read(ID сущности, out [МОД])`;
 * Обновить: `[IsNotExistResult] Logic.Update(ID сущности, ...новые данные)`;
 * Проверить, входит ли мод в сборку: `[IsNotExistResult] InModPack(ID сущности, сборка, out [В СБОРКЕ ИЛИ НЕТ])`;
 * Добавить мод в сборку: `[InModPackResult] AddToModPack(ID сущности, сборка)`;
 * Удалить мод из сборки: `[NotInModPackResult] RemoveFromModPack(ID сущности, сборка)`;
 * Получить все моды из сборки: `[IsNotExistResult] GetAllModsFromModPack(сборка, out [СПИСОК МОДОВ])`.