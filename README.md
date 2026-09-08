# Архитектура ИС

### Термины
 * Сущность: `class MinecraftMod`; <br>
 * База данных: `List<MinecraftMod>`; <br>
 * ID сущности: `string MinecraftMod.Id`; <br>
 * Данные: `Dictionary<string, object>`;
 * Результаты бизнес-функций:
	* `CreateResult` : `NoCorrectData`, `IsExist`, `Successful`;
	* `DeleteResult` : `IsNotExist`, `Successful`;
	* `UpdateResult` : `NoCorrectData`, `IsNotExist`, `Successful`;
	* `SetPublicOrPrivateResult` : `IsNotExist`, `NoChanged`, `Successful`.

### Доступные функции:
 * Создать `[CreateResult] Logic.Create(база данных, сущность)`;
 * Удалить `[DeleteResult] Logic.Delete(база данных, ID сущности)`;
 * Получить данные `[Данные сущности или null] Logic.Read(база данных, ID сущности)`;
 * Обновить данные `[UpdateResult] Logic.Update(база данных, ID сущности, новые данные сущности)`;
 * Сделать публичным `[SetPublicOrPrivateResult] SetPublic(база данных, ID сущности)`;
 * Сделать приватным `[SetPublicOrPrivateResult] SetPrivate(база данных, ID сущности)`.