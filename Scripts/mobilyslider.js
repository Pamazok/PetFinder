/* ==========================================================
 * MobilySlider
 * date: 20.1.2010
 * author: Marcin Dziewulski
 * last update: 02.02.2011
 * web: http://www.mobily.pl or http://playground.mobily.pl
 * email: hello@mobily.pl
 * Free to use under the MIT license.
 * ========================================================== */
(function ($) {
    $.fn.mobilyslider = function (options) {
        var defaults = {
            content: ".sliderContent",
            children: "div",
            transition: "horizontal",
            animationSpeed: 300,
            autoplay: false,
            autoplaySpeed: 3000,
            pauseOnHover: false,
            bullets: true,
            arrows: true,
            arrowsHide: true,
            prev: "prev",
            next: "next",
            animationStart: function () { },
            animationComplete: function () { }
        }; var sets = $.extend({}, defaults, options); return this.each(function () {
            var $t = $(this), item = $t.children(sets.content).children(sets.children), l = item.length - 1, w = item.width(), h = item.height(), step = 0, play, bullets, arrows, z, active, bullet; var slider = {
                init: function () {
                    slider.data(); if (sets.bullets) {
                        slider.bullets.create()
                    } if (sets.arrows) {
                        slider.arrows.create()
                    } if (sets.autoplay) { slider.autoplay() } slider.triggers()
                }, data: function () {
                    item.each(function (i) { $(this).css("z-index", -(i - l)) }); if (sets.transition == "fade") {
                        item.hide().eq(0).show()
                    }
                }, zindex: {
                    prev: function () {
                        step == l ? item.eq(0).css("z-index", l + 3) : item.css("z-index", l + 1); item.eq(step).css("z-index", l + 4).next(item).css("z-index", l + 2)
                    }, next: function () {
                        item.css("z-index", l + 1).eq(step).css("z-index", l + 3).prev(item).css("z-index", l + 2)
                    }, bullets: function () { item.css("z-index", l + 1).eq(active).css("z-index", l + 2); item.eq(step).css("z-index", l + 3) }, trigger: function () {
                        if (z == 1) { slider.zindex.next() } else { if (z == -1) { slider.zindex.prev() } else { if (z == 0) { slider.zindex.bullets() } } }
                    }
                }, slide: {
                    left: function (sign) {
                        sets.animationStart.call(this); item.stop(true, true).eq(step).animate({ left: sign + "=" + w }, sets.animationSpeed, function () {
                            slider.zindex.trigger()
                        }).animate({ left: 0 }, sets.animationSpeed + 200, function () {
                            sets.animationComplete.call(this)
                        })
                    }, top: function (sign) {
                        sets.animationStart.call(this); item.stop(true, true).eq(step).animate({ top: sign + "=" + h }, sets.animationSpeed, function () {
                            slider.zindex.trigger()
                        }).animate({ top: 0 }, sets.animationSpeed + 200, function () { sets.animationComplete.call(this) })
                    }, fade: function () { sets.animationStart.call(this); item.stop(true, true).fadeOut(sets.animationSpeed).eq(step).fadeIn(sets.animationSpeed, function () { sets.animationComplete.call(this) }) }
                }, animation: {
                    previous: function () {
                        step == 0 ? step = l : step--; z = -1; switch (sets.transition) { case "horizontal": slider.slide.left("-"); break; case "vertical": slider.slide.top("+"); break; case "fade": slider.slide.fade(); break }
                    }, next: function () {
                        step == l ? step = 0 : step++; z = 1; switch (sets.transition) { case "horizontal": slider.slide.left("+"); break; case "vertical": slider.slide.top("-"); break; case "fade": slider.slide.fade(); break }
                    }
                }, autoplay: function () {
                    play = setInterval(function () { slider.animation.next(); if (sets.bullets) { setTimeout(function () { slider.bullets.update() }, sets.animationSpeed + 300) } }, sets.autoplaySpeed)
                }, pause: function () {
                    clearInterval(play)
                }, bullets: {
                    create: function () {
                        $t.append($("<div />").addClass("sliderBullets")); bullets = $t.find(".sliderBullets"); for (i = 0; i <= l; i++) { bullets.append($("<a />").attr({ href: "#", rel: i }).text(i)) }
                    }, trigger: function () {
                        bullet = bullets.find("a"); bullet.eq(0).addClass("active"); bullet.click(function () {
                            var b = $(this), rel = b.attr("rel"); active = bullet.filter(".active").attr("rel"); step = rel; sign = rel > active ? "+" : "-"; z = 0; if (!b.hasClass("active")) {
                                switch (sets.transition) {
                                    case "horizontal": slider.slide.left(sign); break;
                                    case "vertical": slider.slide.top(sign); break;
                                    case "fade": slider.slide.fade(); break
                                }
                            } bullet.removeClass("active"); b.addClass("active"); return false
                        })
                    }, update: function () { bullet.removeClass("active").eq(step).addClass("active") }
                }, arrows: {
                    create: function () {
                        $t.append($("<div />").addClass("sliderArrows")); arrows = $t.find(".sliderArrows"); arrows.append($("<a />").attr("href", "#").addClass(sets.prev).text("Previous")); arrows.append($("<a />").attr("href", "#").addClass(sets.next).text("Next"))
                    }, trigger: function () {
                        arrows.find("." + sets.prev).click(function () {
                            slider.animation.previous(); if (sets.bullets) {
                                slider.bullets.update()
                            } return false
                        }); arrows.find("." + sets.next).click(function () { slider.animation.next(); if (sets.bullets) { slider.bullets.update() } return false }); if (sets.arrowsHide) { arrows.hide(); $t.hover(function () { arrows.show() }, function () { arrows.hide() }) }
                    }
                }, triggers: function () {
                    if (sets.arrows) {
                        slider.arrows.trigger()
                    } if (sets.bullets) { slider.bullets.trigger() } if (sets.pauseOnHover) {
                        $t.hover(function () {
                            slider.pause()
                        }, function () { slider.autoplay() })
                    }
                }
            }; slider.init()
        })
    }
}(jQuery));