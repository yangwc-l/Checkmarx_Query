CxList methods = Find_Methods();

	List<string> esqlCommandsWhitelist = new List<string>  {
	"CxESQL_allocate",
	"CxESQL_alter",
	"CxESQL_begin",
	"CxESQL_check",
	"CxESQL_close",
	"CxESQL_commit",
	"CxESQL_create",
	"CxESQL_database",
	"CxESQL_deallocate",
	"CxESQL_declare",
	"CxESQL_delete",
	"CxESQL_describe",
	"CxESQL_drop",
	"CxESQL_execute",
	"CxESQL_fetch",
	"CxESQL_flush",
	"CxESQL_free",
	"CxESQL_get",
	"CxESQL_grant",
	"CxESQL_info",
	"CxESQL_insert",
	"CxESQL_load",
	"CxESQL_lock",
	"CxESQL_open",
	"CxESQL_output",
	"CxESQL_prepare",
	"CxESQL_put",
	"CxESQL_recover",
	"CxESQL_rename",
	"CxESQL_repair",
	"CxESQL_revoke",
	"CxESQL_rollback",
	"CxESQL_rollforward",
	"CxESQL_select",
	"CxESQL_set",
	"CxESQL_start",
	"CxESQL_unload",
	"CxESQL_unlock",
	"CxESQL_update",
	"CxESQL_whenever"
	};

result = methods.FindByShortNames(esqlCommandsWhitelist, false);