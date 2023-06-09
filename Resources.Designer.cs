﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCP_Client_Server {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TCP_Client_Server.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Соединиться.
        /// </summary>
        internal static string LabelClientStart {
            get {
                return ResourceManager.GetString("LabelClientStart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отключиться.
        /// </summary>
        internal static string LabelClientStop {
            get {
                return ResourceManager.GetString("LabelClientStop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Слушать порт.
        /// </summary>
        internal static string LabelServerStart {
            get {
                return ResourceManager.GetString("LabelServerStart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Закрыть порт.
        /// </summary>
        internal static string LabelServerStop {
            get {
                return ResourceManager.GetString("LabelServerStop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ошибка соединения.
        /// </summary>
        internal static string MessageConnection {
            get {
                return ResourceManager.GetString("MessageConnection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Подключение было разорвано..
        /// </summary>
        internal static string MessageConnectionLost {
            get {
                return ResourceManager.GetString("MessageConnectionLost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ошибка IP.
        /// </summary>
        internal static string MessageIP {
            get {
                return ResourceManager.GetString("MessageIP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на IP введён в некорректном формате..
        /// </summary>
        internal static string MessageIPIsInvalid {
            get {
                return ResourceManager.GetString("MessageIPIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Указанный порт по этому IP недоступен..
        /// </summary>
        internal static string MessageIPIsUnavailable {
            get {
                return ResourceManager.GetString("MessageIPIsUnavailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ошибка порта.
        /// </summary>
        internal static string MessagePort {
            get {
                return ResourceManager.GetString("MessagePort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Указанный порт занят или закрыт..
        /// </summary>
        internal static string MessagePortIsBusy {
            get {
                return ResourceManager.GetString("MessagePortIsBusy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Порт введён в нечисловом формате. Задайте порт от 0 до.
        /// </summary>
        internal static string MessagePortIsInvalid {
            get {
                return ResourceManager.GetString("MessagePortIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Невозможное значение порта. Задайте порт от 0 до.
        /// </summary>
        internal static string MessagePortOutOfRange {
            get {
                return ResourceManager.GetString("MessagePortOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ошибка отправки.
        /// </summary>
        internal static string MessageSend {
            get {
                return ResourceManager.GetString("MessageSend", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Сейчас отправка невозможна, так как идёт запись в сетевой поток..
        /// </summary>
        internal static string MessageSendDenied {
            get {
                return ResourceManager.GetString("MessageSendDenied", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Соединение со всеми клиентами было разорвано..
        /// </summary>
        internal static string OutputConnectionAllWereLost {
            get {
                return ResourceManager.GetString("OutputConnectionAllWereLost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Соединение с.
        /// </summary>
        internal static string OutputConnectionEvent {
            get {
                return ResourceManager.GetString("OutputConnectionEvent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на было разорвано.
        /// </summary>
        internal static string OutputConnectionLost {
            get {
                return ResourceManager.GetString("OutputConnectionLost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на было установлено.
        /// </summary>
        internal static string OutputConnectionMade {
            get {
                return ResourceManager.GetString("OutputConnectionMade", resourceCulture);
            }
        }
    }
}
