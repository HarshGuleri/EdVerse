using System;
using System.Collections.Generic;
using System.Text;

namespace EdVerse.ViewModels.Common
{
    public class ConfirmActionVm
    {
        public string ModalId { get; set; } = "confirmModal";

        public string Title { get; set; } = "Confirmation";

        public string Message { get; set; } = string.Empty;

        public string Action { get; set; } = string.Empty;

        public string Controller { get; set; } = string.Empty;

        public int Id { get; set; }

        // Button

        public string ActionButtonText { get; set; } = "Confirm";

        public string ActionButtonClass { get; set; } = "btn-danger";
    }
}