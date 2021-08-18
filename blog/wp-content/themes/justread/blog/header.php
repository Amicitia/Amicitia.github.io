<?php
/**
 * The header for our theme
 *
 * This is the template that displays all of the <head> section and everything up until <div id="content">
 *
 * @link https://developer.wordpress.org/themes/basics/template-files/#template-partials
 *
 * @package Justread
 */

?>
<!doctype html>
<html class="no-js" <?php language_attributes(); ?>>
<head>
	<meta charset="<?php bloginfo( 'charset' ); ?>">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="profile" href="http://gmpg.org/xfn/11">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="shortcut icon" type="image/x-icon" href="https://shrinefox.com/images/favicon.ico">
<link rel="stylesheet" type="text/css" href="https://shrinefox.com/css/spectre.min.css">
<link rel="stylesheet" type="text/css" href="https://shrinefox.com/css/theme.min.css">
<link rel="stylesheet" type="text/css" href="https://shrinefox.com/css/custom.css">
<link rel="stylesheet" type="text/css" href="https://shrinefox.com/css/ytv.css">
<script type="text/javascript" src="https://shrinefox.com/js/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="https://kit.fontawesome.com/4c3075832a.js"></script>
<script type="text/javascript" src="https://shrinefox.com/js/togglesidebar.js"></script>
<script type="text/javascript" src="https://shrinefox.com/js/FeedEk.min.js"></script>
<script type="text/javascript" src="https://shrinefox.com/js/jscolor.js"></script>
<script type="text/javascript" src="https://shrinefox.com/js/themes.js"></script>
<script data-ad-client="ca-pub-9519592525056753" async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<meta charset="utf-8">
	<?php wp_head(); ?>
</head>
<body>
    <div id="page-wrapper">
        <!--Navbar-->
        <section id="header" class="section scrolled">
            <section class="container grid-lg">
                <nav class="navbar">
                    <section class="navbar-section logo">
                        <a href="https://shrinefox.com" class="navbar-brand mr-10">
                            <!--Logo-->
                            <svg version="1.0" class="amicitialogo" xmlns="http://www.w3.org/2000/svg"
                                 width="500.000000pt" height="500.000000pt" viewBox="0 0 500.000000 500.000000"
                                 preserveAspectRatio="xMidYMid meet">
                                <metadata>
                                </metadata>
                                <g transform="translate(0.000000,500.000000) scale(0.100000,-0.100000)"
                                   fill="#ffffff" stroke="none">
                                    <path d="M2256 4489 c-926 -119 -1651 -850 -1766 -1779 -15 -125 -12 -405 5
                                            -529 65 -450 258 -836 579 -1157 67 -66 164 -152 216 -191 136 -100 310 -203
                                            343 -203 14 0 48 114 141 481 l43 166 -143 246 c-78 136 -141 247 -139 247 15
                                            0 424 113 442 122 12 6 20 14 18 18 -2 4 30 132 71 286 41 153 120 445 174
                                            647 l99 369 -143 246 c-121 208 -141 248 -126 254 9 3 113 32 232 63 210 56
                                            215 58 215 84 1 14 37 160 82 324 44 165 78 303 75 308 -7 11 -325 9 -418 -2z" />
                                    <path d="M3135 3840 c-4 -16 -4 -34 -1 -39 3 -4 -39 -249 -94 -542 -55 -294
                                            -100 -546 -100 -561 l0 -28 210 0 210 0 0 28 c0 15 -45 267 -100 561 -55 293
                                            -97 538 -94 542 8 13 -6 69 -16 69 -5 0 -11 -13 -15 -30z" />
                                    <path d="M2806 2008 c-180 -966 -256 -1368 -261 -1390 l-7 -28 606 0 606 0 0
                                            23 c0 13 -56 324 -125 693 -69 368 -128 684 -131 702 l-6 32 -338 0 -338 0 -6
                                            -32z" />
                                </g>
                            </svg>
                        </a>
                    </section>
                    <section class="navbar-section desktop-menu">
                        <nav class="dropmenu animated">
                            <ul>
                                <li>
                                    <a href="https://shrinefox.com" class="homelink">
                                        Home
                                    </a>
                                </li>
                                <li>
                                    <a href="https://shrinefox.com/browse" class="browselink">
                                        Browse
                                    </a>
                                </li>
                                <li>
                                    <a href="https://shrinefox.com/forum" class="forumlink">
                                        Forum
                                    </a>
                                </li>
                                <li>
                                    <a href="https://shrinefox.com/wiki" class="wikilink">
                                        Wiki
                                    </a>
                                </li>
                                <li>
                                    <a style="cursor:pointer;" class="active">
                                        Articles
                                    </a>
                                    <ul>
                                        <li>
                                            <a href="https://shrinefox.com/news" class="newslink">
                                                News
                                            </a>
                                            <ul id="news-feed"></ul>
                                        </li>
                                        <li>
                                            <a href="https://shrinefox.com/guides" class="guideslink">
                                                Guides
                                            </a>
                                            <ul id="guides-feed"></ul>
                                        </li>
                                        <li>
                                            <a href="https://shrinefox.com/blog" class="active">
                                                Blog
                                            </a>
                                            <ul id="blog-feed"></ul>
                                        </li>
                                    </ul>
                                </li>
                                <li>
                                    <a href="https://shrinefox.com/forum/app.php/faqpage" class="faqlink">
                                        FAQ
                                    </a>
                                </li>
                                <li>
                                    <a href="https://shrinefox.com/about" class="aboutlink">
                                        About
                                    </a>
                                </li>
                            </ul>
                        </nav>
                    </section>
                </nav>
            </section>
        </section>
        <script>
            $('#news-feed').FeedEk({
                FeedUrl: 'https://shrinefox.com/news/feed',
                MaxCount: 3,
                ShowDesc: false,
                ShowPubDate: true,
                DescCharacterLimit: 0,
                TitleLinkTarget: '_blank',
                DateFormat: 'MMM d',
                DateFormatLang: 'en'
            });

            $('#guides-feed').FeedEk({
                FeedUrl: 'https://shrinefox.com/guides/feed',
                MaxCount: 3,
                ShowDesc: false,
                ShowPubDate: true,
                DescCharacterLimit: 0,
                TitleLinkTarget: '_blank',
                DateFormat: 'MMM d',
                DateFormatLang: 'en'
            });

            $('#blog-feed').FeedEk({
                FeedUrl: 'https://shrinefox.com/blog/feed',
                MaxCount: 3,
                ShowDesc: false,
                ShowPubDate: true,
                DescCharacterLimit: 0,
                TitleLinkTarget: '_blank',
                DateFormat: 'MMM d',
                DateFormatLang: 'en'
            });
        </script>
        <!--Video Background-->
        <div class="videocontainer">
            <video autoplay muted loop class="videobg">
                <source src="https://shrinefox.com/images/waves2.mp4" type="video/mp4">
            </video>
            <!--Search-->
            <div>
                <script async src="https://cse.google.com/cse.js?cx=38ad766f435ddfed4"></script>
                <div class="gcse-search"></div>
            </div>
        </div>
        <!--Page Content-->
        <section id="start">
            <section id="body-wrapper" class="section">
                <section class="container grid-lg">
                    <table style="width:100%;">
                        <tr>

<div class="toggle-btn" onclick="toggleCookie(this)"><i id="toggle-icon" class="fa fa-bars" aria-hidden="true"></i> Explore</div>
<td class="sidebar inactive" id="sidebar">
	<div class="accordion-container">
		<div class="accordion">
    <input id="accordion-blog" type="checkbox" name="blog-accordion-checkbox" hidden="" checked="checked">
    <label class="accordion-header c-hand" for="accordion-blog"><i class="fa fa-angle-right"></i> Blog</label>
    <div class="accordion-body">
        <ul class="menu menu-nav">
            <div id="blog-latest"></div>
        </ul>
    </div>
</div>
<script>
    $('#blog-latest').FeedEk({
        FeedUrl: 'https://shrinefox.com/blog/feed',
        MaxCount: 6,
        ShowDesc: false,
        ShowPubDate: false,
        TitleLinkTarget: '_blank'
    });
</script><div class="accordion">
    <input id="accordion-browse" type="checkbox" name="browse-accordion-checkbox" hidden="" checked="checked">
    <label class="accordion-header c-hand" for="accordion-browse"><i class="fa fa-angle-right"></i> Browse</label>
    <div class="accordion-body">
        <ul class="menu menu-nav">
            <li class="menu-item">
                <a href="https://shrinefox.com/browse" class="typeall">All</a>
            </li>
            <li class="menu-item">
                <a href="https://shrinefox.com/browse?type=Mod" class="typemod">Mods</a>
            </li>
            <li class="menu-item">
                <a href="https://shrinefox.com/browse?type=Tool" class="typetool">Tools</a>
            </li>
            <li class="menu-item">
                <a href="https://shrinefox.com/browse?type=Guide" class="typeguide">Guides</a>
            </li>
            <li class="menu-item">
                <a href="https://shrinefox.com/browse?type=Cheat" class="typecheat">Cheats</a>
            </li>
        </ul>
    </div>
</div>
<div class="accordion">
    <input id="accordion-apps" type="checkbox" name="apps-accordion-checkbox" hidden="" checked="checked">
    <label class="accordion-header c-hand" for="accordion-apps"><i class="fa fa-angle-right"></i> Apps</label>
    <div class="accordion-body">
        <ul class="menu menu-nav">
            <li class="menu-item">
                <a href="https://shrinefox.com/apps/PatchCreator" class="rpcs3patchlink">RPCS3 Patch Creator</a>
            </li>
            <li class="menu-item">
                <a href="https://shrinefox.com/apps/UpdateCreator" class="ps4patchlink">PS4 Patch Creator</a>
            </li>
            <li class="menu-item">
                <a href="https://shrinefox.com/apps/TextSearch" class="textsearchlink">Text Search</a>
            </li>
            <li class="menu-item">
                <a href="https://shrinefox.com/apps/files" class="fileslink">Files</a>
            </li>
        </ul>
    </div>
</div>
	</div>
</td>
<td class="maincontent"><a href="https://shrinefox.com"><i class="fa fa-home" aria-hidden="true"></i> ShrineFox.com</a> <i class="fa fa-angle-right" aria-hidden="true"></i><a href="https://shrinefox.com/blog">Blog</a>
<?php wp_body_open(); ?>
<div id="page" class="site">
	<a class="skip-link screen-reader-text" href="#content"><?php esc_html_e( 'Skip to content', 'justread' ); ?></a>

	<div class="form-wrapper" id="form-wrapper">
		<button
			class="search-close" id="search-close"
			<?php if ( justread_is_amp() ) : ?>
				on="tap:form-wrapper.toggleClass( class='is-visible', force=false )"
			<?php endif; ?>
		>&times;</button>
		<?php get_search_form(); ?>
	</div>

	<header id="masthead" class="site-header">
		<div class="navbar">
			<div class="site-branding">
				<?php
				the_custom_logo();
				if ( is_front_page() && is_home() ) :
					?>
					<h1 class="site-title"><a href="<?php echo esc_url( home_url( '/' ) ); ?>" rel="home"><?php bloginfo( 'name' ); ?></a></h1>
					<?php
				else :
					?>
					<p class="site-title"><a href="<?php echo esc_url( home_url( '/' ) ); ?>" rel="home"><?php bloginfo( 'name' ); ?></a></p>
					<?php
				endif;

				$description = get_bloginfo( 'description', 'display' );
				if ( $description || is_customize_preview() ) :
					?>
					<p class="site-description"><?php echo wp_kses_post( $description ); ?></p>
				<?php endif; ?>
			</div><!-- .site-branding -->

			<nav id="site-navigation" class="main-navigation">
				<?php
				wp_nav_menu(
					array(
						'theme_location' => 'menu-1',
						'menu_id'        => 'primary-menu',
						'menu_class'     => 'menu',
						'container'      => '',
					)
				);
				?>
			</nav><!-- #site-navigation -->
		</div>
		<div class="social-icons">
			<?php
			if ( function_exists( 'jetpack_social_menu' ) ) {
				jetpack_social_menu();
			}
			?>
			<button
				class="search-toggle" aria-controls="form-wrapper" aria-expanded="false"
				<?php if ( justread_is_amp() ) : ?>
					on="tap:form-wrapper.toggleClass( class='is-visible' )"
				<?php endif; ?>
			><?php echo justread_get_svg( array( 'icon' => 'search' ) ); // wpcs xss: ok. ?></button>
			<button id="site-navigation-open" class="menu-toggle" aria-controls="primary-menu" aria-expanded="false"><?php esc_html_e( 'Menu', 'justread' ); ?></button>
		</div>
	</header><!-- #masthead -->

	<div id="content" class="site-content">
