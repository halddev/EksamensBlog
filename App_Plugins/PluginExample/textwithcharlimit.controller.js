angular.module("umbraco").controller("PluginExample.TextWithCharLimitController", function ($scope) {

    $scope.limitchars = function() {
        var limit = $scope.model.config.limit;
        if ($scope.model.value.length > limit) {
            $scope.info = "You cannot write more than " + limit + "characters!";
            $scope.model.value = $scope.model.value.substr(0, limit);
        }
        else
        {
            $scope.info = "You have " + (limit - $scope.model.value.length) + " characters remaining.";
        }
    };
});